import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";

type Props={
    hike: Hike,
    onHikeCancel: () => void
}

export default function HikeDetail({ hike, onHikeCancel }: Props) {
    return (
        <Card sx={{ borderRadius: 3 }}>
            <CardMedia component="img" src={`/images/venueImages/${hike.venue}.jpg`} />
            <CardContent>
                <Typography variant="h5" fontWeight='bold'>{hike.name} </Typography>
                <Typography variant="subtitle2" fontWeight='light' >{hike.hikeDate}</Typography>
                <Typography variant="body1" >{hike.description} </Typography>
                <Typography variant="subtitle1" >{hike.city} </Typography>
                <Typography variant="subtitle2" >{hike.country} </Typography>
            </CardContent>
            <CardActions sx={{ display: 'flex', justifyContent: 'space-between', p: 2 }}>
                <Button size="medium" variant="contained" color="primary">Edit</Button>
                <Button color="inherit" onClick={onHikeCancel}>Cancel</Button>
            </CardActions>
        </Card>
    )
}