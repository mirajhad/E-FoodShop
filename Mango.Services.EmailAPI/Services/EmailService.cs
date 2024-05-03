﻿using Mango.Services.EmailAPI.Data;
using Mango.Services.EmailAPI.Models;
using Mango.Services.EmailAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.EmailAPI.Services
{
    public class EmailService : IEmailService
    {
        private DbContextOptions<AppDbContext> _dbOptions;

        public EmailService(DbContextOptions<AppDbContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task EmailCartAndLog(CartDto cartDto)
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("<br/>Cart Email Request");
            message.AppendLine("<br/> Total" + cartDto.CartHeader.CartTotal);
            message.Append("<br/>");
            message.Append("<ul>");
            foreach (var item in cartDto.CartDetails) {
                message.Append("<li>");
                message.Append(item.Product.Name + " " + item.Count);
                message.Append("</li>");
            }
            message.Append("</ul>");
            await LogAndEmail(message.ToString(), cartDto.CartHeader.Email);
        }

        public async Task RegisterUserEmailAndLog(string email)
        {
            string message = "User Registration Successfull. <br/> Email:" + email;
            await LogAndEmail(message, "mirajhadish48@gmail.com");
        }

        private async Task<bool> LogAndEmail(string message, string email)
        {
            try
            {
                EmailLogger emailLog = new()
                {
                    Email = email,
                    EmailSent = DateTime.Now,
                    Message = message
                };
                await using var _db = new AppDbContext(_dbOptions);
                await _db.EmailLoggers.AddAsync(emailLog);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
