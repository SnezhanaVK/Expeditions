using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model
{
    public class ClientRegistrationModel 
    {
        public string ForeName
        {
            get;
            set;
        } = string.Empty;
        public string Patronymic
        {
            get;
            set;
        } = string.Empty;

        public string Surname
        {
            get;
            set;
        } = string.Empty;

        public string NumberTelefon
        {
            get;
            set;
        } = string.Empty;
        public string Country
        {
            get;
            set;
        } = string.Empty;
        public string City
        {
            get;
            set;
        } = string.Empty;
        

        public string LevelHealth
        {
            get;
            set;
        } = string.Empty;
        public string Email
        {
            get;
            set;
        } = string.Empty;
        public string Street
        {
            get;
            set;
        } = string.Empty;
        public string NumberHome
        {
            get;
            set;
        } = string.Empty;
        public string Password
        {
            get;
            set;
        } = string.Empty;
    }
}
