import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { WebsocketService } from './websocket.service';

@Injectable({
  providedIn: 'root'
})
export class LatencyService {
  private lastPing: number = 0;
  public latency: BehaviorSubject<number> = new BehaviorSubject(999);

  constructor(private ws: WebsocketService) {
    setInterval(() => { this.pingServer(); }, 1000);
    ws.registerHandler("pong", (resp) => { this.handlePong(); });
  }

  private pingServer(): void {
    const d = new Date();
    this.lastPing = d.getTime();

    this.ws.send('ping', {});
  }

  private handlePong(): void {
    const d = new Date();
    const now = d.getTime();

    this.latency.next(now - this.lastPing);
  }
}
