import { speakerReducer as original_speakerReducer } from './reducers';

export let callCounter = 0;

export function spySpeakerReducer(state, action) {
  callCounter++;

  return original_speakerReducer(state, action);
}
