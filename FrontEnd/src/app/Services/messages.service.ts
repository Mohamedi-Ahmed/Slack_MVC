// Les différents imports
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
// Votre interface

export interface Message{
    id: string,
    content: string,
    authorId: string,
    date: Date,
    threadId: string
}

@Injectable({
    providedIn: 'root',
  })
  export class MessagesService {
    messages = [];
  
    constructor(private http: HttpClient) {}
  
      // Les différentes requêtes HTTP
      getMessages() {
        return this.http.get('http://localhost:5048/messages');
      }
      getMessage(id: string) {
        return this.http.get(`http://localhost:5048/messages/${id}`);      }

      getMessagesByThreadId(threadId: string){
        return this.http.get(`http://localhost:5048/messages?threadId=${threadId}`);      }

      createMessage(message: any){
        return this.http.post("http://localhost:5048/messages", message)
      }

      updateMessage(message: any){
        return this.http.put(`http://localhost:5048/messages/${message.id}`, message)
      }

      deleteMessage(id: string){
        return this.http.delete(`http://localhost:5048/messages/${id}`);
      }
  }