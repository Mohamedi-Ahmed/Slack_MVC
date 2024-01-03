import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Message, MessagesService } from '../../Services/messages.service';
import { User, UserService } from '../../Services/user.service'; // Assurez-vous que le chemin d'importation est correct

@Component({
    selector: 'app-message',
    imports: [CommonModule],
    standalone: true,
    templateUrl: './messages.component.html',
    styleUrls: ['./messages.component.css'],
})
export class MessagesComponent implements OnInit {
    @Input()
    message!: Message;

    author!: User; // Utilisateur auteur du message

    constructor(
        private messagesService: MessagesService,
        private userService: UserService // Injection de UserService
    ) {}

    ngOnInit(): void {
        if (this.message && this.message.authorId) {
            this.userService.getUserById(this.message.authorId).subscribe((userData: any) => {
                this.author = { id: userData.id, username: userData.name };
            });
        }
    }
}