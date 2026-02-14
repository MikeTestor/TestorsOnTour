import { Button, Card, CardActions, CardContent, Chip, Typography } from "@mui/material";

type Props={
    hike: Hike,
    onHikeSelect: (id: string) => void
}

export default function HikeCard({hike, onHikeSelect}: Props) 
{
  return (
    <Card sx={{ borderRadius: 3 }}>
        <CardContent>
            <Typography variant="h5" fontWeight='bold'>{hike.name} </Typography>
            <Typography sx={{color: 'text.secondary', mb: 1}} >{hike.hikeDate}</Typography>
            <Typography variant="body2" fontWeight='bold'>{hike.description} </Typography>
            <Typography variant="subtitle1" fontWeight='bold'>{hike.city} </Typography>
            <Typography variant="subtitle2" fontWeight='bold'>{hike.country} </Typography>            
        </CardContent>
        <CardActions sx={{ display: 'flex', justifyContent: 'space-between', p: 2 }}>
            <Chip label={hike.venue} variant="outlined" />
            <Button size="medium" variant="contained" color="primary" onClick={() => onHikeSelect(hike.id)}>View </Button>
        </CardActions>
    </Card>
  )
}