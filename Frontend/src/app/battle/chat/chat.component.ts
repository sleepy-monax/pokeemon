import { Component, OnInit } from '@angular/core';
import { ChatService } from 'src/app/services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.less']
})
export class ChatComponent implements OnInit {
  public messages: any[];
  public newMessage: string;

  constructor(private cs: ChatService) { }

  ngOnInit(): void {
    this.cs.messages.subscribe((value: any[]) => {
      this.messages = value;
    });
  }

  public sendMessage() {
    if (this.newMessage.trim() === '') {
      return;
    }

    console.log("Chat: " + this.newMessage);

    this.cs.send(this.newMessage);
    this.newMessage = '';
  }
}
