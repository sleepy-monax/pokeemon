import { Component, OnInit } from '@angular/core';
import { WebsocketService } from 'src/app/services/websocket.service';

@Component({
  selector: 'app-connection-status',
  templateUrl: './connection-status.component.html',
  styleUrls: ['./connection-status.component.less']
})
export class ConnectionStatusComponent implements OnInit {

  constructor(private websocket: WebsocketService) { }

  ngOnInit(): void {
    this.websocket.connect()
  }
}
