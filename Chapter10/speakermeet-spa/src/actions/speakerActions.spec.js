import {
  expect
} from 'chai';
import * as speakerActions from './speakerActions';
import * as types from '../reducers/actionTypes';
import * as errorTypes from '../reducers/errorTypes';
import thunk from 'redux-thunk';
import configureMockStore from 'redux-mock-store';
import sinon from 'sinon';
import factory from '../services/serviceFactory';
import { MockSpeakerService } from '../services/mockSpeakerService';

describe('Speaker Actions', () => {
  describe('Sync Actions', () => {
    describe('Get Speakers Success', () => {
      it('exists', () => {
        expect(speakerActions.getSpeakersSuccess).to.exist;
      });

      it('is created with correct data', () => {
        // arrange
        const speakers = [{
          id: 'test-speaker',
          firstName: 'Test',
          lastName: 'Speaker'
        }];

        // act
        const result = speakerActions.getSpeakersSuccess(speakers);

        // assert
        expect(result.type).to.equal(types.GET_SPEAKERS_SUCCESS);
        expect(result.speakers).to.have.lengthOf(1);
        expect(result.speakers).to.deep.equal(speakers);
      });
    });

    describe('Get Speaker Success', () => {
      it('exists', () => {
        expect(speakerActions.getSpeakerSuccess).to.exist;
      });

      it('is created with correct data', () => {
        // arrange
        const speaker = {
          id: 'test-speaker',
          firstName: 'Test',
          lastName: 'Speaker'
        };

        // act
        const result = speakerActions.getSpeakerSuccess(speaker);

        // assert
        expect(result.type).to.equal(types.GET_SPEAKER_SUCCESS);
        expect(result.speaker).to.deep.equal(speaker);
      });
    });

    describe('Get Speaker Failure', () => {
      it('exists', () => {
        expect(speakerActions.getSpeakerFailure).to.exist;
      });

      it('is created with correct data', () => {
        // arrange
        const error = {
          type: errorTypes.SPEAKER_NOT_FOUND
        };

        // act
        const result = speakerActions.getSpeakerFailure(error);

        // assert
        expect(result.type).to.equal(types.GET_SPEAKER_FAILURE);
        expect(result.error).to.deep.equal(error);
      });
    });
  });

  describe('Async Actions', () => {
    const middleware = [thunk];
    let mockStore;
    let create;
    let getAll;
    let getById;

    beforeEach(() => {
      let service = factory.createSpeakerService();
      let mockService = new MockSpeakerService();

      getAll = sinon.stub(service, "getAll");
      getAll.callsFake(mockService.getAll.bind(mockService));

      getById = sinon.stub(service, "getById");
      getById.callsFake(mockService.getById.bind(mockService));

      create = sinon.stub(service, "create");
      create.callsFake(mockService.create.bind(mockService));

      mockStore = configureMockStore(middleware);
    });

    afterEach(() => {
      create.restore();
      getAll.restore();
      getById.restore();
    });

    describe('Get Speakers', () => {
      it('exists', () => {
        expect(speakerActions.getSpeakers).to.exist;
      });

      it('creates GET_SPEAKERS_SUCCESS when loading speakers', () => {
        // arrange
        const speaker = {
          id: 'test-speaker',
          firstName: 'Test',
          lastName: 'Speaker'
        };
        const expectedActions = [speakerActions.getSpeakersSuccess([speaker])];
        const store = mockStore({
          speakers: []
        });

        // act
        return store.dispatch(speakerActions.getSpeakers()).then(() => {
          const actions = store.getActions();

          // assert
          expect(actions[0].type).to.equal(types.GET_SPEAKERS_SUCCESS);
        });
      });
    });

    describe('Get Speaker', () => {
      it('exists', () => {
        expect(speakerActions.getSpeaker).to.exist;
      });

      it('creates GET_SPEAKER_FAILURE when speaker is not found', () => {
        // arrange
        const speakerId = 'not-found-speaker';
        const store = mockStore({
          speaker: {}
        });

        // act
        return store.dispatch(speakerActions.getSpeaker(speakerId)).then(() => {
          const actions = store.getActions();

          // assert
          expect(actions[0].type).to.equal(types.GET_SPEAKER_FAILURE);
        });
      });

      it('creates GET_SPEAKER_SUCCESS when speaker is found', () => {
        // arrange
        const speaker = {
          id: 'test-speaker',
          firstName: 'Test',
          lastName: 'Speaker'
        };
        const store = mockStore({
          speaker: {}
        });
        let service = factory.createSpeakerService();
        service.create(speaker);

        // act
        return store.dispatch(speakerActions.getSpeaker('test-speaker')).then(() => {
          const actions = store.getActions();

          // assert
          expect(actions[0].type).to.equal(types.GET_SPEAKER_SUCCESS);
          expect(actions[0].speaker.id).to.equal('test-speaker');
          expect(actions[0].speaker.firstName).to.equal('Test');
          expect(actions[0].speaker.lastName).to.equal('Speaker');
        });
      });
    });
  });
});
