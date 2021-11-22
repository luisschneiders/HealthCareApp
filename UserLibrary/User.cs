﻿using System;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace UserLibrary
{
    public class User : Base
    {
        private string _userId;
        private string _userName;
        private string _userPassword;
        private ContactDetails _userContactDetails;
        private Location _userLocation;

        // constructor
        public User()
        {
        }

        // method Save
        public void Save(User user)
        {
            // Add validation for fields

            UserId = Guid.NewGuid().ToString();
            UserName = user.UserName;
            UserPassword = user.UserPassword;
            UserContactDetails = user.UserContactDetails;
            UserLocation = user.UserLocation;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;

        }

        public string UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string UserPassword
        {
            get => _userPassword;
            set => _userPassword = value;
        }

        public ContactDetails UserContactDetails
        {
            get => _userContactDetails;
            set => _userContactDetails = value;
        }

        public Location UserLocation
        {
            get => _userLocation;
            set => _userLocation = value;
        }
    }
}
