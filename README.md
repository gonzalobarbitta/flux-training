# Flux Training

### Prerequisites

You will need to have Kubernetes set up. In my case, I am using Kubernetes on Docker Desktop for Windows.
Install fluxctl which provides an API that can be used from the command line.

### Create the flux namespace

```
kubectl create ns flux
```

### Install flux

```
export GHUSER="gonzalobarbitta"
fluxctl install \
--git-user=${GHUSER} \
--git-email=${GHUSER}@users.noreply.github.com \
--git-url=git@github.com:${GHUSER}/flux-training \
--git-path=workloads \
--namespace=flux | kubectl apply -f -
```

### Sync cluster with Git repository

Flux's main feature is the automated synchronisation between a version control repository and a cluster. In other words, if you make any changes to your repository, those changes are automatically deployed to your cluster.

```
fluxctl sync --k8s-fwd-ns flux
```

### Give write access

At startup, flux generates a SSH key. SSH public key can be found running `fluxctl identity --k8s-fwd-ns flux`.
Copy this key and create a deploy key with write access on your GitHub repository.

### Automated deployment of new container images

Flux can also be used to automate container image updates in your cluster, and it does so by continuously monitoring container registries and deploying new versions where applicable.

One way to enable this feature is by annotating your deployments using `fluxcd.io/automated: "true"`.

You can also use `fluxcd.io/tag.app: semver:~1.0` to instruct flux to only update the image when you push an image tag that matches the semantic version expression e.g cloud-sample:1.0.1 but not cloud-sample:1.2.0.
