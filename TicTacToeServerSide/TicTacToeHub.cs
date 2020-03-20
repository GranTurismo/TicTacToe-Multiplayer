using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeServerSide
{
    public class TicTacToeHub : Hub
    {
        public static List<Group> MyGroups = new List<Group>();
        public async void Join(string id)
        {
            Group relevantGroup = null;
            if (MyGroups.Count == 0)
                relevantGroup = MakeNewGroup(id);
            if (relevantGroup is null)
            {
                relevantGroup = MyGroups.FirstOrDefault(o => o.UserIds.Count < 2);
                if (relevantGroup is null)
                    relevantGroup = MakeNewGroup(id);
            }
            relevantGroup.UserIds.Add(id);
            await CallBackToClient(relevantGroup);
        }

        private async Task CallBackToClient(Group relevantGroup) => await Clients.Caller.SendAsync("JoinCallback", relevantGroup.Id.ToString());

        private Group MakeNewGroup(string id)
        {
            var newGroup = new Group();
            newGroup.UserIds.Add(id);
            return newGroup;
        }
    }

    public class Group
    {
        bool WasFinished { get; set; } = false;
        public Guid Id { get; private set; }
        public List<string> UserIds { get; } = new List<string>();

        public Group()
        {
            Id = Guid.NewGuid();
        }
    }
}
