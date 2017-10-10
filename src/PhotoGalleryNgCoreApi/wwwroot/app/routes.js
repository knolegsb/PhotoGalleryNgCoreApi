System.register(['@angular/router', './components/home.component', './components/photos.component', './components/albums.component', './components/album-photos.component'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, home_component_1, photos_component_1, albums_component_1, album_photos_component_1;
    var appRoutes, routing;
    return {
        setters:[
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (home_component_1_1) {
                home_component_1 = home_component_1_1;
            },
            function (photos_component_1_1) {
                photos_component_1 = photos_component_1_1;
            },
            function (albums_component_1_1) {
                albums_component_1 = albums_component_1_1;
            },
            function (album_photos_component_1_1) {
                album_photos_component_1 = album_photos_component_1_1;
            }],
        execute: function() {
            appRoutes = [
                {
                    path: '',
                    redirectTo: '/home',
                    pathMatch: 'full'
                },
                {
                    path: 'home',
                    component: home_component_1.HomeComponent
                },
                {
                    path: 'photos',
                    component: photos_component_1.PhotosComponent
                },
                {
                    path: 'albums',
                    component: albums_component_1.AlbumsComponent
                },
                {
                    path: 'albums/:id/photos',
                    component: album_photos_component_1.AlbumPhotosComponent
                }
            ];
            exports_1("routing", routing = router_1.RouterModule.forRoot(appRoutes));
        }
    }
});
//# sourceMappingURL=routes.js.map