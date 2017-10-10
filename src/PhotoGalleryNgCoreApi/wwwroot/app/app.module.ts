import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';

//import { AccountModule } from './components/account/account.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home.component';
import { AlbumPhotosComponent } from './components/album-photos.component';
import { AlbumsComponent } from './components/albums.component';
import { PhotosComponent } from './components/photos.component';

import { routing } from './routes';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing
    ],
    declarations: [AppComponent, HomeComponent, AlbumPhotosComponent, PhotosComponent, AlbumsComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }