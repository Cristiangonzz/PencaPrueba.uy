import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateEquipoDto } from '../../../intraestructure/dto/create/CreateEquipoDTO';
import { EquipoService } from '../../../domain/services/EquipoService';
import { Router } from '@angular/router';
import { equipoUseCaseProviders } from '../../../intraestructure/delegate/delegate-equipo/delegateEquipo';

@Component({
  selector: 'app-create-equipo',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateEquipoComponent implements OnInit {

  factory = equipoUseCaseProviders;


  FormCreate = new FormGroup({
    name: new FormControl('', [Validators.required]),
 
  });
  equipo: CreateEquipoDto =
    {
      name: ""
    }
  constructor(
    private readonly equipoService: EquipoService,
    private router: Router,
  ) { }


    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }


  send(): void {

    this.equipo.name = this.FormCreate.get('name')?.value as string;
   // this.equipo = this.FormCreate.getRawValue() as CreateEquipoDto;
    this
      .factory
      .createEquipoUseCaseProvider
      .useFactory(this.equipoService)
      .execute(this.equipo)
      .subscribe(
        (response) => {
          this.factory.getAllEquipoUseCaseProvider.useFactory(this.equipoService).execute();
          console.log(response);
          //this.succes();
          //this.router.navigate([`home/home`]);
        },
        (error) => {
          console.log(error);
        /*  this.error();*/
        });
  }




}
