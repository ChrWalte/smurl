import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ILink } from 'src/app/shared/interfaces/ILink';

import { LinkService } from 'src/app/shared/services/link-service/link.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss'],
})
export class CreateComponent implements OnInit {
  @ViewChild('onError', { static: true })
  public onErrorTemplate!: TemplateRef<any>;
  @ViewChild('onCreate', { static: true })
  public onCreateTemplate!: TemplateRef<any>;

  isSlugParam: boolean = false;
  givenSlugParam!: string;

  createdLink!: ILink;
  fullLink!: string;

  failedResonse!: string;

  linkForm: FormGroup = new FormGroup({
    url: new FormControl('', [Validators.required]),
    slug: new FormControl(''),
  });

  constructor(
    private route: ActivatedRoute,
    private linkService: LinkService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.handleParameter();
  }

  get url() {
    return this.linkForm.get('url');
  }

  get slug() {
    return this.linkForm.get('slug');
  }

  isUrlEmpty(): boolean {
    return this.url?.value === '';
  }

  createSmurl(): void {
    var link: any = {
      url: this.url?.value,
      slug: this.slug?.value,
    };

    this.linkService.createLink(link).subscribe((response) => {
      if (response.status === 'Success') {
        this.createdLink = response.value as ILink;
        this.fullLink = `https://smurl.xyz/${this.createdLink.slug}`;
        this.openModal(this.onCreateTemplate);
      } else {
        this.failedResonse = response.message;
        this.openModal(this.onErrorTemplate);
      }
    });
  }

  private handleParameter(): void {
    this.route.paramMap.subscribe((params) => {
      this.linkForm.patchValue({ slug: params.get('slug') || '' });

      if (this.slug?.value !== '') {
        this.givenSlugParam = this.slug?.value;
        this.isSlugParam = true;
      }
    });
  }

  private openModal(template: any) {
    this.modalService.open(template, { windowClass: 'site-modal' });
  }
}
