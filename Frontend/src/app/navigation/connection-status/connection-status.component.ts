import { Component, OnInit } from '@angular/core';
import { connected } from 'process';
import { LatencyService } from 'src/app/services/latency.service';
import { WebsocketService } from 'src/app/services/websocket.service';

@Component({
  selector: 'app-connection-status',
  templateUrl: './connection-status.component.html',
  styleUrls: ['./connection-status.component.less']
})
export class ConnectionStatusComponent implements OnInit {

  public connected: boolean = false;
  public message: string = 'Disconnected';
  public latency: number = 0;


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
