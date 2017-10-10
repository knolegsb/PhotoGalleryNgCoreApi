import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';

//import { AccountModule } from './components/account/account.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [AppComponent, HomeComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }