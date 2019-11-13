﻿using System;

namespace Domain
{
    public class Organization : Entity
    {
        public string PublicKey { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}