import { Component, OnInit } from '@angular/core';
import { IAllMatchesDomain } from '../../domain/interfaces/ApiMatches/IAllMatches';
import { HttpClient } from '@angular/common/http';
import { IMatcheDomain } from '../../domain/interfaces/ApiMatches/IMatcheDomain';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrl: './match.component.css'
})
export class MatchComponent implements OnInit {

  matches!: IMatcheDomain[];
  constructor(

    private http: HttpClient,

  ) { }



  ngOnInit(): void {


    this.getAll();
  }




  getAll() {
    var URL = 'http://localhost:5046/Equipo/matches';
    return this.http.get(URL).subscribe(x => {
      var match: IAllMatchesDomain;
      match = x as IAllMatchesDomain;
      this.matches = match.matches;
      console.log(this.matches);
    })
  }
}
