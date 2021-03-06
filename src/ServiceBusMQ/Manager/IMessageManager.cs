#region File Information
/********************************************************************
  Project: ServiceBusMQManager
  File:    IMessageManager.cs
  Created: 2012-08-30

  Author(s):
    Daniel Halan

 (C) Copyright 2012 Ingenious Technology with Quality Sweden AB
     all rights reserved

********************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBusMQ.Model;

namespace ServiceBusMQ.Manager {
  public interface IMessageManager : IDisposable {


    void Init(string serverName, string[] commandQueues, string[] eventQueues,
                      string[] messageQueues, string[] errorQueues, CommandDefinition commandDef);


    bool IsIgnoredQueueItem(QueueItem itm);

    void MoveErrorItemToOriginQueue(QueueItem itm);
    void MoveAllErrorItemsToOriginQueue(string errorQueue);

    bool IsIgnoredQueue(string queueName);

    MessageContentFormat MessageContentFormat { get; }

    string LoadMessageContent(QueueItem itm);

    string[] GetAllAvailableQueueNames(string server);
    bool CanAccessQueue(string server, string queueName);

    void RefreshQueueItems();


    void PurgeMessage(QueueItem itm);
    void PurgeAllMessages();
    
    void PurgeErrorMessages(string queueName);
    void PurgeErrorAllMessages();


    string BusName { get; }
    string BusQueueType { get; }


    string[] EventQueues { get; }
    string[] CommandQueues { get; }
    string[] MessageQueues { get; }
    string[] ErrorQueues { get; }

    bool MonitorCommands { get; set; }
    bool MonitorEvents { get; set; }
    bool MonitorMessages { get; set; }
    bool MonitorErrors { get; set; }


    List<QueueItem> Items { get; }


    event EventHandler ItemsChanged;
    event EventHandler<ErrorArgs> ErrorOccured;

    void ClearProcessedItems();

    void LoadProcessedQueueItems(TimeSpan timeSpan);
  }
}
