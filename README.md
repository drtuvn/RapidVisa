# RapidVisa

Timesheet web app using mvc + entityframework code first.

What should have been done differently?
- Refractor its controller into Interface csproj
- Refractor its concreate implementation into microservices using web api, so later if we want to use Ruby as backend services, we just need to swap those api without any needs to update the main web app.
- Mock the web api to test.
- Use bootstrap, modenizer, and dapper to help with cosmetics.
- Add a bunch of unit testing and mocking services
- Create the identity model and map that to our employee model that way we can just lean on what Microsoft has and will be easy to integrate with OAuth and 3rd party sign on
- Time is not my friend for this project. I should not be too ambitious at first when I went ahead with creating the web API as microservices then found out that my vm doesn't work with the docker container (unless I have to physically turn hypervisor V on). Thus, I can't deployed these microservices on the cloud
