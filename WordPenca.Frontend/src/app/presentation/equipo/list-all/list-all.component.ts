import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { equipoUseCaseProviders } from '../../../intraestructure/delegate/delegate-equipo/delegateEquipo';
import { EquipoDomainEntity } from '../../../domain/entity/EquipoEntity';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Router } from '@angular/router';
import { ResponseDomainEntity } from '../../../domain/entity/ResponseEntity';
import { Observable, Subscription } from 'rxjs';
import { IMatcheDomain } from '../../../domain/interfaces/ApiMatches/IMatcheDomain';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-list-all',
  templateUrl: './list-all.component.html',
  styleUrl: './list-all.component.css'
})
export class ListAllComponent implements OnInit, AfterViewInit {
  delegateCategoria = equipoUseCaseProviders;
  listEquipos!: EquipoDomainEntity[];
  mostrarComponente: boolean = false;
  matches!: IMatcheDomain[];

  //Puebla de WebSocket

  messages: string[] = [];

  data$!: Observable<ResponseDomainEntity<EquipoDomainEntity[]>>;
  //@Input() crearCategoria!: boolean;
  //sweet = new SweetAlert();
  private statusSubscription: Subscription | undefined;

  constructor(
    private equipoService: EquipoService,
    private router: Router,

  ) {
  
  }

 
  ngAfterViewInit(): void {
    window.scroll(0, 0)
  }
  finalizarCreacion() {
    this.mostrarComponente = false;
  }
 
  ngOnInit(): void {


    this.delegateCategoria.getAllEquipoUseCaseProvider
      .useFactory(this.equipoService)
      .execute(); // Le agrego los valores a el Emisor

    this.data$ = this.delegateCategoria.getAllEquipoUseCaseProvider
      .useFactory(this.equipoService).getAllEquipoObservable(); // Obtengo el valor nuevo de lo que alguien emitio

  }
}
