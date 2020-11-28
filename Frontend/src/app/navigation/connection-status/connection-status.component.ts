import { Component, OnInit } from '@angular/core';
import { connected } from 'process';
import { WebsocketService } from 'src/app/services/websocket.service';

@Component({
  selector: 'app-connection-status',
  templateUrl: './connection-status.component.html',
  styleUrls: ['./connection-status.component.less']
})
export class ConnectionStatusComponent implements OnInit {

  public connected: boolean = false;
  public message: string = 'Disconnected';


  constructor(private websocket: WebsocketService) {

  }


  ngOnInit(): void {
    this.websocket.connect()

    this.websocket.isConnected.subscribe((value: boolean) => {
      this.connected = value;

      if (value) {
        this.message = 'Connected';
      } else {
        this.message = 'Disconnected';
      }
    });
  }
}
