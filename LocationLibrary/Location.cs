﻿using System;

namespace LocationLibrary
{

    public partial class Location
    {
        private Guid _id;
        private string _address;
        private float _lat;
        private float _lng;
        private string _suburb;
        private string _postcode;
        private string _state;

        // constructor
        public Location()
        {
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }
        public float Lat
        {
            get => _lat;
            set => _lat = value;
        }

        public float Lng
        {
            get => _lng;
            set => _lng = value;
        }

        public string Suburb
        {
            get => _suburb;
            set => _suburb = value;
        }

        public string Postcode
        {
            get => _postcode;
            set => _postcode = value;
        }

        public string State
        {
            get => _state;
            set => _state = value;
        }

    }

}
