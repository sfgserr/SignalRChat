import React from 'react';

export const PublicPage = () => {
    let id = process.env.REACT_APP_IDENTITY_CLIENT_ID;
    let text = 'Public page';
    
    return (
        <div>
            {id}
            {text}
        </div>
    );
};
