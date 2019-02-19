import * as types from '../reducers/actionTypes';
import factory from "../services/serviceFactory";

export function getSpeakersSuccess(speakers) {
  return { type: types.GET_SPEAKERS_SUCCESS, speakers: speakers };
}

export function getSpeakerSuccess(speaker) {
  return { type: types.GET_SPEAKER_SUCCESS, speaker: speaker };
}

export function getSpeakerFailure(error) {
  return { type: types.GET_SPEAKER_FAILURE, error: error }
}

export function getSpeakers() {
  return function(dispatch) {
    return factory.createSpeakerService().getAll().then(speakers => {
      dispatch(getSpeakersSuccess(speakers))
    }).catch(err => {
      throw(err);
    });
  };
}

export function getSpeaker(speakerId) {
  return function(dispatch) {
    return factory.createSpeakerService().getById(speakerId).then(
      speaker => {
        dispatch(getSpeakerSuccess(speaker));
      }).catch(err => {
        dispatch(getSpeakerFailure(err));
      });
  };
}
