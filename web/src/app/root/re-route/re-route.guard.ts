import { Inject, Injectable } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { LinkService } from 'src/app/shared/services/link-service/link.service';

@Injectable({
  providedIn: 'root',
})
export class ReRouteGuard implements CanActivate {
  constructor(
    private linkService: LinkService,
    private router: Router,
    @Inject(DOCUMENT) private document: Document
  ) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    var providedSlug =
      route.params.slug || route.paramMap.get('slug') || route.params['slug'];

    console.log(providedSlug);
    console.log(route.params.slug);
    console.log(route.paramMap.get('slug'));
    console.log(route.params['slug']);

    this.linkService.getLink(providedSlug).subscribe((response) => {
      if (response.status === 'Success') {
        this.document.location.href = response.value.url;
        return false;
      } else {
        this.router.navigate(['crud', 'create', providedSlug]);
        return false;
      }
    });

    this.router.navigate(['/']);
    return false;
  }
}
