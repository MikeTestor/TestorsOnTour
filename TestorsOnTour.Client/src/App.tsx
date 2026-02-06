import { useEffect, useState } from 'react';
import './App.css'

function App() {  
  const name = 'Testors On Tour';
  const [hikes, setHikes] = useState([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/hikes')
      .then(response => response.json())
      .then(data => setHikes(data))
      .catch(error => console.error('Error fetching hikes:', error));
  }, []);

  return (
    <div>
      <h3 className='app' style={{color: 'red'}}>{name}</h3>
      <ul>
        {hikes.map(hike => (
          <li key={hike.id}>{hike.name}</li>
        ))}
      </ul>

    </div>


  )
}

export default App
