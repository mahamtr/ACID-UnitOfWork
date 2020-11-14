import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { TranslateModule } from '@ngx-translate/core';

import { FuseModule } from '@fuse/fuse.module';
import { FuseSharedModule } from '@fuse/shared.module';
import { FuseProgressBarModule, FuseSidebarModule, FuseThemeOptionsModule } from '@fuse/components';

import { fuseConfig } from 'app/fuse-config';

import { FakeDbService } from 'app/fake-db/fake-db.service';
import { AppComponent } from 'app/app.component';
import { AppStoreModule } from 'app/store/store.module';
import { LayoutModule } from 'app/layout/layout.module';
import {AuthHeaderInterceptor} from './interceptors/header.interceptor';
import {CatchErrorInterceptor} from './interceptors/http-error.interceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';
const appRoutes: Routes = [
    {
        path        : 'pages',
        loadChildren: () => import('./main/pages/pages.module').then(m => m.PagesModule)
    },
    {
        path      : '**',
        redirectTo: 'pages/auth/login'
    },
    // {
    //     path        : 'apps',
    //     loadChildren: () => import('./main/apps/apps.module').then(m => m.AppsModule)
    // },

    // {
    //     path        : 'ui',
    //     loadChildren: () => import('./main/ui/ui.module').then(m => m.UIModule)
    // },
    // {
    //     path        : 'documentation',
    //     loadChildren: () => import('./main/documentation/documentation.module').then(m => m.DocumentationModule)
    // },

];

@NgModule({
    declarations: [
        AppComponent
    ],
    imports     : [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        RouterModule.forRoot(appRoutes),

        TranslateModule.forRoot(),
        InMemoryWebApiModule.forRoot(FakeDbService, {
            delay             : 0,
            passThruUnknownUrl: true
        }),

        // Material moment date module
        MatMomentDateModule,

        // Material
        MatButtonModule,
        MatIconModule,MatSnackBarModule,

        // Fuse modules
        FuseModule.forRoot(fuseConfig),
        FuseProgressBarModule,
        FuseSharedModule,
        FuseSidebarModule,
        FuseThemeOptionsModule,

        // App modules
        LayoutModule,
        AppStoreModule
    ],
    providers: [
        {
          provide: HTTP_INTERCEPTORS,
          useClass: AuthHeaderInterceptor,
          multi: true,
        },
        {
          provide: HTTP_INTERCEPTORS,
          useClass: CatchErrorInterceptor,
          multi: true,
        },
       
      ],
    bootstrap   : [
        AppComponent
    ]
})
export class AppModule
{
}
