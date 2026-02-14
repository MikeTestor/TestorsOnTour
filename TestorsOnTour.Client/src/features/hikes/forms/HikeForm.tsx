import { Box, Button, Paper, TextField, Typography } from "@mui/material";

export default function HikeForm() {
  return (
    <Paper sx={{ borderRadius: 3, p: 3 }}>
        <Typography variant="h5" gutterBottom color="primary">
            Create a new hike
        </Typography>
        <Box component="form" display='flex' flexDirection='column' gap={3}>
            <TextField label="Hike Name" />            
            <TextField label="Description" multiline rows={4} />
            <TextField label="Date" type="date" />
            <TextField label="City" />
            <TextField label="Country"/>
            <TextField label="Venue" />
            <Box display='flex' justifyContent='flex-end' gap={2} mt={2}>                
                <Button variant="outlined" color="inherit">Cancel</Button>
                <Button variant="contained" color="success">Submit</Button>
            </Box>
            
        </Box>

    </Paper>
  )
}