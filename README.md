# Flux Training

# Prerequisites

You will need to have Kubernetes set up. In my case, I am using Kubernetes on Docker Desktop for Windows.
Install fluxctl which provides an API that can be used from the command line.

# Create the flux namespace

```
kubectl create ns flux
```

# Install flux

```
export GHUSER="gonzalobarbitta"
fluxctl install \
--git-user=${GHUSER} \
--git-email=${GHUSER}@users.noreply.github.com \
--git-url=git@github.com:${GHUSER}/flux-get-started \
--git-path=workloads \
--namespace=flux | kubectl apply -f -
```

# Give write access

At startup, Flux generates a SSH key. SSH public can be found running `fluxctl identity --k8s-fwd-ns flux`.
Copy this key and create a deploy key with write access on your GitHub repository.
