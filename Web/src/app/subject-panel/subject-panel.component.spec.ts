import {async, ComponentFixture, TestBed} from '@angular/core/testing';

import {SubjectPanelComponent} from './subject-panel.component';

describe('SubjectPanelComponent', () => {
  let component: SubjectPanelComponent;
  let fixture: ComponentFixture<SubjectPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SubjectPanelComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SubjectPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
