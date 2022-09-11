import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = []

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  /**
   * getEventos: método para fazer request de todos os eventos
   * return: array of Evento
   */
  public getEventos(): void {
    this.http. 
      get('https://localhost:7046/api/Evento').
      subscribe(
        response => this.eventos = response,
        error => console.log(error)
      );
  }

}