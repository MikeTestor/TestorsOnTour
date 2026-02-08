import { useEffect, useState } from 'react';
import './App.css'
import { List, ListItem, ListItemText, Typography } from '@mui/material';
import axios from 'axios';

function App() {
  const name = 'Testors On Tour';
  const [hikes, setHikes] = useState<Hike[]>([]);

  // useEffect(() => {
  //   fetch('https://localhost:5001/api/hikes')
  //     .then(response => response.json())
  //     .then(data => setHikes(data))
  //     .catch(error => console.error('Error fetching hikes:', error));
  // }, []);

  // axios.get('https://localhost:5001/api/hikes')
  //   .then(response => setHikes(response.data))
  //   .catch(error => console.error('Error fetching hikes:', error));

  useEffect(() => {
    axios.get<Hike[]>('https://localhost:5001/api/hikes')
      .then(response => setHikes(response.data))
      .catch(error => console.error('Error fetching hikes:', error));
  }, []);
  

  return (
    <>
      <Typography variant='h3'>{name}</Typography>
      <List>
        {hikes.map(hike => (
          <ListItem>
            <ListItemText>{hike.name}</ListItemText>
          </ListItem>
        ))}
      </List>

    </>

  )
}

export default App
