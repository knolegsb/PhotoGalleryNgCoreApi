import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';

@Component({
    selector: 'photogallery-app',
    templateUrl: './app/app.component.html'
})

export class AppComponent implements OnInit {
    constructor(public location: Location) {  }

    ngOnInit() { }
}