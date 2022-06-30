import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClimaComponentComponent } from './clima-component.component';

describe('ClimaComponentComponent', () => {
  let component: ClimaComponentComponent;
  let fixture: ComponentFixture<ClimaComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClimaComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClimaComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
