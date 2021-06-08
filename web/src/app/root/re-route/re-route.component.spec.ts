import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReRouteComponent } from './re-route.component';

describe('ReRouteComponent', () => {
  let component: ReRouteComponent;
  let fixture: ComponentFixture<ReRouteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReRouteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReRouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
