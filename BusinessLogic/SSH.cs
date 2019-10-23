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
            var keyFile = new PrivateKeyFile(@"/home/support/key_mod.ppk");

            var keyFiles = new[] { keyFile };

            var PrivateKeyConnection = new PrivateKeyAuthenticationMethod("support", keyFiles);

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "support", PrivateKeyConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                string commandScript;
                commandScript = "ip a";
                var command = ssh.RunCommand(commandScript);
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }

        public string SSHFolderInfo(string hostIP)
        {

            var keyFile = new PrivateKeyFile(@"/home/support/key_mod.ppk");

            var keyFiles = new[] { keyFile };

            var PrivateKeyConnection = new PrivateKeyAuthenticationMethod("support", keyFiles);

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "support", PrivateKeyConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                string commandScript;
                commandScript = "ls -l";
                var command = ssh.RunCommand(commandScript);
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }
        public string TCPDumpLaunch(string hostIP, string Interface, int TCPPacketsParsed)
        {

            var keyFile = new PrivateKeyFile(@"/home/support/key_mod.ppk");

            var keyFiles = new[] { keyFile };

            var PrivateKeyConnection = new PrivateKeyAuthenticationMethod("support", keyFiles);

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "support", PrivateKeyConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                string commandScript;
                commandScript = "tcpdump -c " + TCPPacketsParsed + " -pinn -t " + Interface;
                var command = ssh.RunCommand(commandScript);
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }
        public string ChangeInterfaceSettings(string hostIP, string Interface, string DiscoveredIP, string AccessIP)
        {

            var keyFile = new PrivateKeyFile(@"/home/support/key_mod.ppk");

            var keyFiles = new[] { keyFile };

            var PrivateKeyConnection = new PrivateKeyAuthenticationMethod("support", keyFiles);

            string myData = null;

            var connectionInfo = new ConnectionInfo(hostIP, "support", PrivateKeyConnection);

            using (SshClient ssh = new SshClient(connectionInfo))
            {
                ssh.Connect();
                string commandScript;
                commandScript = "iptables -t nat -A PREROUTING -j DNAT -d " + AccessIP + " —to-destination=" + DiscoveredIP + ";iptables -t nat  A POSTROUTING -d " + DiscoveredIP + " -j MASQUERADE; ifconfig " + Interface + ":1 10.114.199.253/24";
                var command = ssh.RunCommand(commandScript);
                myData = command.Result;
                ssh.Disconnect();
            }
            return myData;

        }
    }
}
