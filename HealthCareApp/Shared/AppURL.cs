﻿using System;
namespace HealthCareApp.Shared
{
    public class AppURL
    {
        public readonly string Home;
        public readonly string Dashboard;
        public readonly string About;

        public readonly string Admin;
        public readonly string AdminEmployees;
        public readonly string AdminDepartments;
        public readonly string AdminBarcodes;

        public readonly string API;
        public readonly string APIGet;
        public readonly string APIPost;
        public readonly string APIPut;
        public readonly string APIDelete;

        public readonly string Playground;
        public readonly string PlaygroundCard;

        public readonly string Tasks;
        public readonly string TasksHistoryMop;

        public AppURL()
        {
            Home = "/";
            Dashboard = "/dashboard";
            About = "/about";

            Admin = "/admin";
            AdminEmployees = $"{Admin}/employees";
            AdminDepartments = $"{Admin}/departments";
            AdminBarcodes = $"{Admin}/barcodes";

            API = "/api";
            APIGet = $"{API}/get";
            APIPost = $"{API}/post";
            APIPut = $"{API}/put";
            APIDelete = $"{API}/delete";

            Playground = "/playground";
            PlaygroundCard = $"{Playground}/card";

            Tasks = "/tasks";
            TasksHistoryMop = $"{Tasks}/history-mop";
        }
    }
}
