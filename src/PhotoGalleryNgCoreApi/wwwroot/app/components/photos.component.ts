import { Component, OnInit } from '@angular/core';
import { Photo } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';

@Component({
    selector: 'photos',
    templateUrl: './app/components/photos.component.html'
})
export class PhotosComponent extends Paginated implements OnInit {
    constructor() { }

    ngOnInit() { }
}