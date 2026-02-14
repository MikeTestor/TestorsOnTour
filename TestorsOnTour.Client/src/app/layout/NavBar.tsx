import Group from "@mui/icons-material/Group";
import { Box, AppBar, Toolbar, Typography, Container, MenuItem, Button } from "@mui/material";

export default function NavBar() {
  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static" sx={{backgroundImage: 'linear-gradient(135deg, #182a73, #218aae, #20a7ac 89%)'}}>
        <Container maxWidth="xl">
          <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
            <Box>
                <MenuItem sx={{display: 'flex', gap: 2}}>
                <Group fontSize="large" />
                <Typography variant="h4" fontWeight='bold' sx={{ ml: 1 }}>
                    Testors On Tour
                </Typography>
                </MenuItem>
            </Box>            
            <Box sx={{ display: 'flex', gap: 4 }}>
                <MenuItem sx={{fontSize: '1.2rem', fontWeight: 'bold', textTransform: 'uppercase'}}>
                    Hikes                                
                </MenuItem>
                <MenuItem sx={{fontSize: '1.2rem', fontWeight: 'bold', textTransform: 'uppercase'}}>
                    About
                </MenuItem>
                <MenuItem sx={{fontSize: '1.2rem', fontWeight: 'bold', textTransform: 'uppercase'}}>
                    Contact                                
                </MenuItem>
            </Box>
            <Button size="large" variant="contained" color="warning" >
                Create Hike
            </Button>
          </Toolbar>
        </Container>
      </AppBar>
    </Box>
  )
}