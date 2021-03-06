﻿using COSMO.Business.Abstractions;
using COSMO.Data.Abstractions.Repositories;
using COSMO.Models.Common;
using COSMO.Models.UserModule;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace COSMO.Business
{
    /// <summary>
    /// The user service.
    /// </summary>
    public class UserService : IUserService
    {
        #region Private members

        /// <summary>
        /// The repository for user related data methods.
        /// </summary>
        private IUserRepository _userRepository { get; set; }

        /// <summary>
        /// The app settings object.
        /// </summary>
        private readonly AppSettings _appSettings;

        #endregion

        /// <summary>
        /// Constructor for user service.
        /// </summary>
        /// <param name="userRepository">User repository to inject.</param>
        /// <param name="appSettings">The app setting to inject.</param>
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// The authenticate method to validate user and issue claims.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user object with token.</returns>
        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetUser(username, password).Result;

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.GivenName,user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
