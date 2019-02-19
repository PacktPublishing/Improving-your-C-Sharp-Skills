import React from 'react';

const SpeakerDetail = ({speaker}) => {
  return (
    <div>
      <h1>Speaker Detail</h1>
      <h2><span id="first-name">{speaker.firstName}</span> {speaker.lastName}</h2>
    </div>
  );
};

export default SpeakerDetail;
