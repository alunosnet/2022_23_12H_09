using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Trabalho_Final_MOD_17E.Data;

namespace Trabalho_Final_MOD_17E.Models
{
    public class AppRoleProvider : RoleProvider
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var user = db.Users.Where(u => u.email == username).First();
                if (user == null) throw new Exception();
                if (user.perfil == 0)
                    return new string[] { "Administrador" };
                else
                    return new string[] { "Utilizador" };
            }
            catch
            {
                return new string[] { "" };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                var user = db.Users.Where(u => u.email == username).First();
                if (user == null) throw new Exception();
                if (user.perfil == 0 && roleName != "Administrador")
                    throw new Exception();
                if (user.perfil == 1 && roleName != "Utilizador")
                    throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return roleName == "Administrador" || roleName == "Utilizador";
        }
    }
}