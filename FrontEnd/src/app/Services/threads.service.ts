// Les differents imports
// Import des modules HttpClient et Injectable depuis Angular
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

// Votre interface
export interface Thread{
    id: string,
    label: string
}

@Injectable({
    providedIn: 'root',
  })
  export class ThreadsService {
    constructor(private http: HttpClient) {
      this.getThreads().subscribe((threads: any) => {
        this.threads = threads;
        console.log(this.threads);
      });
    }
    threads = this.getThreads();


      // Les différentes requêtes HTTP

    // Récuperer de la liste des threads
      getThreads() {
        return this.http.get('http://localhost:5048/threads');
      }

      // Récuperer un thread spécifique selon l'id
      getThread(id: string){
        return this.http.get(`http://localhost:5048/threads/`+id)
      }

      // Creer un nouveau thread dans threads
      createThread(thread: any){
        return this.http.post("http://localhost:5048/threads/",thread)
      }

      // Maj un thread existant selon son id
      updateThread(thread: any){
        return this.http.put(`http://localhost:5048/threads/${thread.id}`, thread)
      }

      //Supprimer un thread selon l'id
      deleteThread(id: string){
        return this.http.delete(`http://localhost:5048/threads/`+id)
      }
  }