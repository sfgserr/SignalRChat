import React from 'react';
import SearchBar from '../components/searchBar';
import './privatePage.css';
import { useState } from 'react';
import searchService from '../services/searchService.js'

export const PrivatePage = () => {
    const [data, setData] = useState([]);

    const handleSearch = (query) => {
        searchService
        .findUsers(query)
        .then((response) => {
          setData(response.data);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    }

    return (
        <div>
            <div className='container'>
                <SearchBar searchButtonClicked={handleSearch}/>
            </div>
           <div>
            {data.id}
            {data.name}
           </div>
        </div>
    );
};
