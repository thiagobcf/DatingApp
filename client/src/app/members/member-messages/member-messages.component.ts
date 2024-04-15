import { Component, Input, OnInit } from '@angular/core';
import { Message } from '../../_models/message';
import { MessageService } from '../../_services/message.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-member-messages',
  standalone: true,
  templateUrl: './member-messages.component.html',
  styleUrls: ['./member-messages.component.css'],
  imports: [CommonModule],
})
export class MemberMessagesComponent implements OnInit {  
  @Input() username?: string;
  @Input() messages: Message[] = [];

  constructor() { }

  ngOnInit(): void {    
  }

}
