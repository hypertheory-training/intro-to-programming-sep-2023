# Business Clock API

We need a way for other applications to make a request to determine if we are currently open or closed.

1. What resource 
/clock

2. What method from HTTP is appropriate
GET /clock

3. What data needs to be sent along the request to process this request
Nothing

4. What data will be returned if you successfully process this request.

true | false


## Design of GET /clock

```json
{
    "open": true
}

```

```json

{
    "open": false,
    "opensNext": "2023-09-23T12:00:33.1656798-04:00"
}
```