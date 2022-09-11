import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

// private declarations
  private eventos: any = []  
  private _filtroLista: string = '';

// public declarations
  public eventosFiltrados: any = []

  // properties of image style
  public widthImg: number = 150;
  public marginImg: number = 2;
  
  // button for image in table header
  public showImage: boolean = false;

/** ------------------------------------------------------------------------
   * Getter && Setter para '_filtroLista'
   */ 
  public get filtroLista(){
    return this._filtroLista;
  }
  public set filtroLista(value : string) {
    this._filtroLista = value;
    if (this.filtroLista) {
      this.eventosFiltrados = this.filtrarEventos(this.filtroLista)
    }else{
      this.eventosFiltrados = this.eventos;
    }    
  }


  /** ------------------------------------------------------------------------
   * método para filtrar a lista de eventos de 
   * acordo com o valor inserido no filtro
   */
  private filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: {tema: string; local: string}) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1 
    );
  }


  /** ------------------------------------------------------------------------
   * método construtor da classe
   */
  constructor(private http: HttpClient) { }


  /** ------------------------------------------------------------------------
   * ngOnInit: método executado quando iniciar o objeto
   * return: void
   */
  ngOnInit(): void {
    this.getEventos();
  }


  /** ------------------------------------------------------------------------
   * getEventos: método para fazer request de todos os eventos
   * return: array of Evento
   */
  public getEventos(): void {
    this.http. 
      get('https://localhost:7046/api/Evento').
      subscribe(
        response => {
          this.eventos = response
          this.eventosFiltrados = this.eventos
        },
        error => console.log(error)
      );
  }
}
