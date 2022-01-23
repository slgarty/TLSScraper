import axios from 'axios';
import React, { useState, useEffect } from 'react';

const TLSScraper = () => {
    const [results, setResults] = useState([]);
    
    useEffect(() => {
        const scrapeTLS = async () => {
            const { data } = await axios.get(`/api/scraper/scrape`);
            setResults(data);
        }
        scrapeTLS()
    },
        [])


    return (
        <div className="container" style={{ marginTop: 60 }}>

            <div className="row">
                <div className="col-md-12">
                    {!!results.length && <table className="table table-header table-bordered table-striped">
                        <thead>
                            <tr>
                                <th>Image</th>
                                <th>Title</th>
                                <th>Blurb</th>
                                <th>Comments</th>
                            </tr>
                        </thead>
                        <tbody>
                            {results.map((result, idx) => <tr key={idx}>
                                <td>
                                    <img width="100 px" src={result.imageUrl} />
                                </td>
                                <td>
                                    <a target="_blank" href={result.linkUrl}>
                                        {result.title}
                                    </a>
                                </td>
                                <td>
                                    {result.blurb}
                                </td>
                                <td>
                                    {result.commentAmount}
                                </td>
                              
                            </tr>)}
                        </tbody>
                    </table>}
                </div>
            </div>
        </div>
    )
}

export default TLSScraper;