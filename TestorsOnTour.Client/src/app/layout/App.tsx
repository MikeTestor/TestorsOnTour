import { useEffect, useState } from 'react';
import { Box, Container, CssBaseline } from '@mui/material';
import axios from 'axios';
import NavBar from './NavBar';
import HikesDashboard from '../../features/hikes/dashboard/HikesDashboard';

function App() {
  const [hikes, setHikes] = useState<Hike[]>([]);
  const [selectedHike, setSelectedHike] = useState<Hike | undefined>(undefined);  

  useEffect(() => {
    axios.get<Hike[]>('https://localhost:5001/api/hikes')
      .then(response => setHikes(response.data))
      .catch(error => console.error('Error fetching hikes:', error));
  }, []);

  const handleHikeSelect = (id: string) => {
    setSelectedHike(hikes.find(h => h.id === id));
  }

  const handleHikeCancel = () => {
    setSelectedHike(undefined);
  }
  

  return (
    <Box sx={{backgroundColor: '#eeeeee'}}>    
      <CssBaseline/>
      <NavBar />
      <Container maxWidth="xl" sx={{ mt: 3 }}>
        <HikesDashboard hikes={hikes} 
                        selectedHike={selectedHike} 
                        onHikeSelect={handleHikeSelect} 
                        onHikeCancel={handleHikeCancel} />
      </Container>
    </Box>
  )
}

export default App
