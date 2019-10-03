using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Renci.SshNet;
using Microsoft.EntityFrameworkCore;
using EquipmentControl.Data;
using EquipmentControl.Models;

namespace EquipmentControl.BusinessLogic
{
    public class SSH
    {
        public string SSHGetInterfaces(string hostIP)
        {

            var PasswordConnection = new PasswordAuthenticationMethod("m.burtsev", "Thu-2331");

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "m.burtsev", PasswordConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand("ip a");
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }

        public string SSHFolderInfo(string hostIP)
        {

            var PasswordConnection = new PasswordAuthenticationMethod("m.burtsev", "Thu-2331");

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "m.burtsev", PasswordConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                var command = ssh.RunCommand("ls -l");
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }
    }
}
