import React from 'react';
import { PropTypes } from 'prop-types';
import { Link } from 'react-router-dom';

export const SpeakerListRow = ({speaker}) => {
  return (
    <tr className="speaker">
      <td className="speaker-name">{speaker.firstName} {speaker.lastName}</td>
      <td><Link className="speaker-link" to={`/speakers/${speaker.id}`}>Details</Link></td>
    </tr>
  );
};

SpeakerListRow.propTypes = {
  speaker: PropTypes.object.isRequired
};

export default SpeakerListRow;
