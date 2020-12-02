import { Component, OnInit } from '@angular/core';
import { connected } from 'process';
import { LatencyService } from 'src/app/services/latency.service';
import { WebsocketService } from 'src/app/services/websocket.service';

@Component({
  selector: 'app-connection',
  templateUrl: './connection.component.html',
  styleUrls: ['./connection.component.less']
})
export class ConnectionComponent implements OnInit {
  public connected = false;
  public message = 'Disconnected';
  public latency = 0;

  constructor(private ws: WebsocketService, private ls: LatencyService) {

  }

  ngOnInit(): void {
    this.ws.isConnected.subscribe((value: boolean) => {
      this.connected = value;

      if (value) {
        this.message = 'Connected';
      } else {
        this.message = 'Disconnected';
      }
    });

    this.ls.latency.subscribe((value) => {
      this.latency = value;
    });
  }
}
